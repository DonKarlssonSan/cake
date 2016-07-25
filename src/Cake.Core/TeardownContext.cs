﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Core
{
    /// <summary>
    /// Acts as a context providing info about the overall build following its completion
    /// </summary>
    public sealed class TeardownContext : CakeContextAdapter, ITeardownContext
    {
        private readonly Exception _thrownException;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeardownContext"/> class.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="throwException">The exception that was thrown by the target.</param>
        public TeardownContext(ICakeContext context, Exception throwException)
            : base(context)
        {
            _thrownException = throwException;
        }

        /// <summary>
        /// Gets a value indicating whether this build was successful
        /// </summary>
        /// <value>
        /// <c>true</c> if successful; otherwise <c>false</c>.
        /// </value>
        public bool Successful
        {
            get { return _thrownException == null; }
        }

        /// <summary>
        /// Gets the exception that was thrown by the target.
        /// </summary>
        public Exception ThrownException
        {
            get { return _thrownException; }
        }
    }
}