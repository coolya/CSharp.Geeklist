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
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;

using Spring.Http;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace Spring.Social.Geeklist.Api.Impl
{
	/// <summary>
	/// Implementation of <see cref="IFollowingOperations"/>, providing binding to Geeklists' following-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class FollowingTemplate : AbstractGeeklistOperations, IFollowingOperations
	{
		private RestTemplate restTemplate;

		public FollowingTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			this.restTemplate = restTemplate;
		}

		#region IFollowingOperations Members

		public FollowingContainer GetUserFollowing()
		{
			return this.GetUserFollowing(1, 10);
		}

		public FollowingContainer GetUserFollowing(int page, int count)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<FollowingContainer>(this.BuildUrl("user/following", parameters));
		}

		public FollowingContainer GetUserFollowing(string screenName)
		{
			return this.GetUserFollowing(screenName, 1, 10);
		}

		public FollowingContainer GetUserFollowing(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObject<FollowingContainer>(this.BuildUrl("users/" + screenName + "/following", parameters));
		}

		public Task<FollowingContainer> GetUserFollowingAsync()
		{
			return this.GetUserFollowingAsync(1, 10);
		}

		public Task<FollowingContainer> GetUserFollowingAsync(int page, int count)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<FollowingContainer>(this.BuildUrl("user/following", parameters));
		}

		public Task<FollowingContainer> GetUserFollowingAsync(string screenName)
		{
			return this.GetUserFollowingAsync(screenName, 1, 10);
		}

		public Task<FollowingContainer> GetUserFollowingAsync(string screenName, int page, int count)
		{
			NameValueCollection parameters = BuildPagingParametersWithCount(page, count);
			return this.restTemplate.GetForObjectAsync<FollowingContainer>(this.BuildUrl("users/" + screenName + "/following", parameters));
		}

		#endregion

		#region Private Methods



		#endregion
	}
}