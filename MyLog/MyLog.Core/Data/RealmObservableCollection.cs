using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using MyLog.Core.Extensions;
using Realms;

namespace MyLog.Core.Data
{
    internal class RealmObservableCollection<TRealmObject, TObject> : ObservableCollection<TObject>
        where TRealmObject : RealmObject
    {
        private readonly IRealmCollection<TRealmObject> _realmCollection;
        private readonly Func<TRealmObject, TObject> _converter;

        public RealmObservableCollection(IRealmCollection<TRealmObject> realmCollection,
            Func<TRealmObject, TObject> converter) : base(realmCollection.Select(converter))
        {
            _realmCollection = realmCollection;
            _converter = converter;
            realmCollection.CollectionChanged += ChangesHandler;
        }

        private void ChangesHandler(object sender, NotifyCollectionChangedEventArgs args)
        {
            Clear();
            _realmCollection.Select(_converter).ForEach(Add);
            return;

            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (Count == args.NewStartingIndex)
                    {
                        foreach (var item in args.NewItems.OfType<TRealmObject>())
                        {
                            Add(_converter(item));
                        }
                    }
                    
                    break;
                case NotifyCollectionChangedAction.Move:
                    throw new NotImplementedException();
                    break;
                case NotifyCollectionChangedAction.Remove:
                    throw new NotImplementedException();
                    break;
                case NotifyCollectionChangedAction.Replace:
                    throw new NotImplementedException();
                    break;
                case NotifyCollectionChangedAction.Reset:
                    throw new NotImplementedException();
                    break;
            }
        }
    }
}
