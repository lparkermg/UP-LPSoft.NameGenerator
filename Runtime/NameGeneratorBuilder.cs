// <copyright file="NameGeneratorBuilder.cs" company="Luke Parker">
// Copyright (c) Luke Parker. All rights reserved.
// </copyright>

namespace LPSoft.NameGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    /// <summary>
    /// Builder for the <see cref="NameGenerator"/>.
    /// </summary>
    public class NameGeneratorBuilder
    {
        private IDictionary<string, string[]> _currentData = new Dictionary<string, string[]>();

        /// <summary>
        /// Provides names by adding a key.
        /// </summary>
        /// <param name="path">The path of the json file.</param>
        /// <returns>The <see cref="NameGeneratorBuilder"/> itself.</returns>
        public NameGeneratorBuilder AddKey(string key, string[] items)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key must be set.");
            }

            if (items == null || items.length == 0)
            {
                throw new ArgumentException("Items must be provided.");
            }

            _currentData.Add(key, items);

            return this;
        }

        /// <summary>
        /// Provides names from a dictionary.
        /// </summary>
        /// <param name="data">The provided data.</param>
        /// <returns>The <see cref="NameGeneratorBuilder"/> itself.</returns>
        public NameGeneratorBuilder FromDictionary(IDictionary<string, string[]> data)
        {
            if (data == null)
            {
                throw new ArgumentException("Dictionary cannot be null.");
            }

            foreach (var key in data.Keys)
            {
                _currentData.Add(key, data[key]);
            }

            return this;
        }

        /// <summary>
        /// Builds a new <see cref="NameGenerator"/>.
        /// </summary>
        /// <param name="rng">The Random Number Generator to use when building names.</param>
        /// <returns>A new <see cref="NameGenerator"/>.</returns>
        public NameGenerator Build(ICanRandom rng) => new NameGenerator((IReadOnlyDictionary<string, string[]>)_currentData, rng);
    }
}
