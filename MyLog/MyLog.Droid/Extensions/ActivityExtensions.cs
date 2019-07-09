using System.Threading.Tasks;
using Android.Support.V7.App;
using Android.Views;
using ActionMode = Android.Support.V7.View.ActionMode;

namespace MyLog.Droid.Extensions
{
    public static class ActivityExtensions
    {
        public static Task<int> StartActionModeAsync(this AppCompatActivity appCompatActivity, int menuResId)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();
            var actionModeCallback = new SupportActionModeCallback(menuResId, taskCompletionSource);
            appCompatActivity.StartSupportActionMode(actionModeCallback);

            return taskCompletionSource.Task;
        }

        private class SupportActionModeCallback : Java.Lang.Object, ActionMode.ICallback
        {
            private readonly int _menuRes;
            private readonly TaskCompletionSource<int> _taskCompletionSource;

            private int _selectedItemId;

            public SupportActionModeCallback(int menuRes, TaskCompletionSource<int> taskCompletionSource)
            {
                _menuRes = menuRes;
                _taskCompletionSource = taskCompletionSource;
            }

            bool ActionMode.ICallback.OnCreateActionMode(ActionMode mode, IMenu menu)
            {
                mode.MenuInflater.Inflate(_menuRes, menu);
                return true;
            }

            public bool OnPrepareActionMode(ActionMode mode, IMenu menu)
            {
                return true;
            }

            public bool OnActionItemClicked(ActionMode mode, IMenuItem item)
            {
                _selectedItemId = item.ItemId;
                mode.Finish();
                return true;
            }

            public void OnDestroyActionMode(ActionMode mode)
            {
                _taskCompletionSource.TrySetResult(_selectedItemId);
            }
        }
    }
}