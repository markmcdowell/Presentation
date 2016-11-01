using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Presentation.Core;

namespace Presentation.Collections
{
    /// <summary>
    /// A keyed collection that will raise events when adding, removing and clearing.
    /// </summary>
    /// <typeparam name="TKey">The type of keys.</typeparam>
    /// <typeparam name="TItem">The type of the items.</typeparam>
    public sealed class ObservableKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private const string CountString = "Count";
        private const string IndexerName = "Item[]";

        private readonly Func<TItem, TKey> _keyFunction;

        /// <summary>
        /// Specify a key function to generate the keys for each item.
        /// </summary>
        /// <param name="keyFunction">The key function.</param>
        public ObservableKeyedCollection(Func<TItem, TKey> keyFunction)
        {
            if (keyFunction == null)
                throw new ArgumentNullException(nameof(keyFunction));

            _keyFunction = keyFunction;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected override TKey GetKeyForItem(TItem item)
        {
            return _keyFunction(item);
        }

        protected override void SetItem(int index, TItem item)
        {
            var originalItem = this[index];
            base.SetItem(index, item);

            PropertyChanged.Raise(this, IndexerName);
            CollectionChanged.Raise(this, NotifyCollectionChangedAction.Replace, originalItem, item, index);
        }

        protected override void InsertItem(int index, TItem item)
        {
            base.InsertItem(index, item);

            PropertyChanged.Raise(this, IndexerName);
            PropertyChanged.Raise(this, CountString);
            CollectionChanged.Raise(this, NotifyCollectionChangedAction.Add, item, index);
        }

        protected override void ClearItems()
        {
            base.ClearItems();

            PropertyChanged.Raise(this, IndexerName);
            PropertyChanged.Raise(this, CountString);
            CollectionChanged.Reset(this);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            base.RemoveItem(index);

            PropertyChanged.Raise(this, IndexerName);
            PropertyChanged.Raise(this, CountString);
            CollectionChanged.Raise(this, NotifyCollectionChangedAction.Remove, item);
        }
    }
}
