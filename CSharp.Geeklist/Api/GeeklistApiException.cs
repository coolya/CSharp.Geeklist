﻿#region License

/*
 * Copyright 2002-2012 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.Runtime.Serialization;

namespace CSharp.Geeklist.Api
{
    /// <summary>
    /// The exception that is thrown when a error occurs while consuming Geeklist REST API.
    /// </summary>
    /// <author>Scott Smith</author>
    
    class GeeklistApiException : Exception
    {
        private readonly GeeklistApiError _error;
        private readonly string _serverResponse;

        /// <summary>
        /// Gets the Geeklist error.
        /// </summary>
        public GeeklistApiError Error
        {
            get { return _error; }
        }

        public string ServerResponse
        {
            get { return _serverResponse; }
        }
            

        /// <summary>
        /// Creates a new instance of the <see cref="GeeklistApiException"/> class.
        /// </summary>
        /// <param name="message">A message about the exception.</param>
        /// <param name="error">The Geeklist error.</param>
        public GeeklistApiException(string message, GeeklistApiError error)
            : base(message)
        {
            _error = error;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="GeeklistApiException"/> class.
        /// </summary>
        /// <param name="message">A message about the exception.</param>
        /// <param name="innerException">The inner exception that is the cause of the current exception.</param>
        public GeeklistApiException(string message, string serverResponse, Exception innerException)
            : base(message, innerException)
        {
            _error = GeeklistApiError.ServerError;
            _serverResponse = serverResponse;
        }
    }
}
