using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Droid.Views;
using MyLog.Core.Services;
using Uri = Android.Net.Uri;

namespace MyLog.Droid.Services
{
    public class FileInputService : IFileInputService
    {
        private const int FileSelectedRequestCode = 1235;

        private static MvxAppCompatActivity CurrentActivity => (MvxAppCompatActivity) Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

        private TaskCompletionSource<Stream> _streamWaitingTaskCompletionSource;

        public async Task<string> ImportTextAsync()
        {
            string text = "";

            try
            {
                _streamWaitingTaskCompletionSource = new TaskCompletionSource<Stream>();
                CurrentActivity.ActivityResultCalled += OnActivityResult;

                var chooseFileIntent = new Intent(Intent.ActionGetContent);
                chooseFileIntent.SetType("text/csv");
                //chooseFileIntent.AddCategory(Intent.CategoryOpenable);
                var chooser = Intent.CreateChooser(chooseFileIntent, "- Choose file -");
                CurrentActivity.StartActivityForResult(chooser, FileSelectedRequestCode);

                using (var stream = await _streamWaitingTaskCompletionSource.Task)
                using (var streamReader = new StreamReader(stream))
                {
                    text = await streamReader.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                CurrentActivity.ActivityResultCalled -= OnActivityResult;
                _streamWaitingTaskCompletionSource.TrySetCanceled();
                _streamWaitingTaskCompletionSource = null;
            }

            return text;
        }

        private void OnActivityResult(object sender, MvxValueEventArgs<MvxActivityResultParameters> args)
        {
            if (args.Value.RequestCode == FileSelectedRequestCode)
            {
                var inputStream = OpenStreamForUri(args.Value.Data.Data);
                _streamWaitingTaskCompletionSource.SetResult(inputStream);
            }
        }

        private Stream OpenStreamForUri(Uri uri)
        {
            var openableMimeTypes = CurrentActivity.ContentResolver.GetStreamTypes(uri, "text/csv").ToArray();
            return CurrentActivity.ContentResolver.OpenTypedAssetFileDescriptor(uri, openableMimeTypes[0], null)
                .CreateInputStream();
        }
    }
}