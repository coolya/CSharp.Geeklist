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
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Models
{
	/// <summary>
	/// Represents a Geeklist user.
	/// </summary>
	/// <author>Scott Smith</author>
	
	public sealed class User
	{
		[JsonProperty("active_at")]
		public string ActiveAt { get; set; }

		[JsonProperty("bio")]
		public string Bio { get; set; }

		[JsonProperty("blog_link")]
		public string BlogLink { get; set; }

		[JsonProperty("created_at")]
		public string CreatedAt { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("featured_cards")]
		public IList<string> FeaturedCards { get; set; }

		[JsonProperty("is_beta")]
		public bool IsBeta { get; set; }

		[JsonProperty("is_featured")]
		public bool IsFeatured { get; set; }

		[JsonProperty("is_trending")]
		public bool IsTrending { get; set; }

		[JsonProperty("location")]
		public string Location { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("screen_name")]
		public string ScreenName { get; set; }

		[JsonProperty("social_links")]
		public IList<string> SocialLinks { get; set; }

		[JsonProperty("trending_at")]
		public string TrendingAt { get; set; }

		[JsonProperty("trending_hist")]
		public IList<TrendingHistory> TrendingHist { get; set; }

		[JsonProperty("settings")]
		public Settings Settings { get; set; }

		[JsonProperty("criteria")]
		public Criteria Criteria { get; set; }

		[JsonProperty("social")]
		public Social Social { get; set; }

		[JsonProperty("company")]
		public Company Company { get; set; }

		[JsonProperty("avatar")]
		public Avatar Avatar { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}

	/// <summary>
	/// Represents a Geeklist user settings.
	/// </summary>
	/// <author>Scott Smith</author>
	
	public sealed class Settings
	{
		[JsonProperty("h5")]
		public H5Settings H5 { get; set; }

		[JsonProperty("micro")]
		public MicroSettings Micro { get; set; }
	}

	/// <summary>
	/// Represents a Geeklist user H5 settings.
	/// </summary>
	/// <author>Scott Smith</author>
	
	public sealed class H5Settings
	{
		[JsonProperty("tweet")]
		public bool Tweet { get; set; }
	}

	/// <summary>
	/// Represents a Geeklist user micro settings.
	/// </summary>
	/// <author>Scott Smith</author>
	
	public sealed class MicroSettings
	{
		[JsonProperty("card")]
		public CardSettings Card { get; set; }

		[JsonProperty("tweet")]
		public bool Tweet { get; set; }
	}

	/// <summary>
	/// Represents a Geeklist user card settings.
	/// </summary>
	/// <author>Scott Smith</author>
	
	public sealed class CardSettings
	{
		[JsonProperty("headline")]
		public string Headline { get; set; }

		[JsonProperty("eid")]
		public string Id { get; set; }
	}
}
