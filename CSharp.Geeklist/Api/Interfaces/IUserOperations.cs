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

using System.Threading.Tasks;
using CSharp.Geeklist.Api.Models;
using Windows.Foundation;

namespace CSharp.Geeklist.Api.Interfaces
{
    /// <summary>
	/// Interface defining the operations for Geeklist user data.
    /// </summary>
    /// <author>Scott Smith</author>
    public interface IUserOperations
    {
		/// <summary>
        /// Retrieves the authenticated user's Geeklist profile details.
	    /// </summary>
        /// <returns>A <see cref="UserResponse"/> object representing the user's profile.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
	    UserResponse GetUser();

        /// <summary>
        /// Retrieves a specific user's Geeklist profile details. 
        /// </summary>
        /// <param name="screenName">The screen name for the user whose details are to be retrieved.</param>
        /// <returns>A <see cref="UserResponse"/> object representing the user's profile.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
	    UserResponse GetUser(string screenName);

#if WINMD
        /// <summary>
        /// Asynchronously retrieves the authenticated user's Geeklist profile details.
        /// </summary>
        /// <returns>A <see cref="UserResponse"/> object representing the user's profile.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        IAsyncOperation<UserResponse> GetUserAsync();

        /// <summary>
        /// Asynchronously retrieves a specific user's Geeklist profile details. 
        /// </summary>
        /// <param name="screenName">The screen name for the user whose details are to be retrieved.</param>
        /// <returns>A <see cref="UserResponse"/> object representing the user's profile.</returns>
        /// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
        IAsyncOperation<UserResponse> GetUserAsync(string screenName);
#else
		/// <summary>
		/// Asynchronously retrieves the authenticated user's Geeklist profile details.
		/// </summary>
		/// <returns>A <see cref="UserResponse"/> object representing the user's profile.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<UserResponse> GetUserAsync();

		/// <summary>
		/// Asynchronously retrieves a specific user's Geeklist profile details. 
		/// </summary>
		/// <param name="screenName">The screen name for the user whose details are to be retrieved.</param>
		/// <returns>A <see cref="UserResponse"/> object representing the user's profile.</returns>
		/// <exception cref="GeeklistApiException">If there is an error while communicating with Geeklist.</exception>
		Task<UserResponse> GetUserAsync(string screenName);
#endif
    }
}
