﻿using System.Collections;
using System.Collections.Generic;
using Skybrud.Umbraco.GridData.Interfaces;

namespace Skybrud.Umbraco.GridData.Converters {

    /// <summary>
    /// Collection of <code>IGridConverter</code>.
    /// </summary>
    public class GridConverterCollection : IEnumerable<IGridConverter> {

        #region Private fields

        private readonly List<IGridConverter> _converters = new List<IGridConverter> {
                new GridConverter()
        };

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <code>converter</code> to the collection.
        /// </summary>
        /// <param name="converter">The converter to be added.</param>
        public void Add(IGridConverter converter) {
            _converters.Add(converter);
        }

        /// <summary>
        /// Adds the specified <code>converter</code> to the collection at <code>index</code>.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="converter">The converter to be added.</param>
        public void AddAt(int index, IGridConverter converter) {
            _converters.Insert(index, converter);
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void Clear() {
            _converters.Clear();
        }

        /// <summary>
        /// Removes the specified <code>converter</code> from the collection.
        /// </summary>
        /// <param name="converter">The converter to be removed.</param>
        public void Remove(IGridConverter converter) {
            _converters.Remove(converter);
        }

        /// <summary>
        /// Removes the converter at the specified <code>index</code>.
        /// </summary>
        /// <param name="index">The index of the converter to be removed.</param>
        public void RemoveAt(int index) {
            _converters.RemoveAt(index);
        }

        public IEnumerator<IGridConverter> GetEnumerator() {
            return _converters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }

}