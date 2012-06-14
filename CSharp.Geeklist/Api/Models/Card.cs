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
	/// Represents a Geeklist card.
	/// </summary>
	/// <author>Scott Smith</author>
	
	public class Card
	{
		[JsonProperty("author_id")]
		public string AuthorId { get; set; }

		[JsonProperty("created_at")]
		public string CreatedAt { get; set; }

		[JsonProperty("headline")]
		public string Headline { get; set; }

		[JsonProperty("is_active")]
		public bool IsActive { get; set; }

		[JsonProperty("is_trending")]
		public bool IsTrending { get; set; }

		[JsonProperty("permalink")]
		public string Permalink { get; set; }

		[JsonProperty("skills")]
		public List<string> Skills { get; set; }

		[JsonProperty("slug")]
		public string Slug { get; set; }

		[JsonProperty("tasks")]
		public List<string> Tasks { get; set; }

		[JsonProperty("trending_at")]
		public string TrendingAt { get; set; }

		[JsonProperty("trending_by")]
		public string TrendingBy { get; set; }

		[JsonProperty("trending_hist")]
		public List<TrendingHistory> TrendingHist { get; set; }

		[JsonProperty("updated_at")]
		public string UpdatedAt { get; set; }

		[JsonProperty("stats")]
		public Stats Stats { get; set; }

		[JsonProperty("short_code")]
		public ShortCode ShortCode { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("contributors")]
		public List<Contributor> Contributors { get; set; }

		[JsonProperty("has_highfived")]
		public bool HasHighfived { get; set; }

		[JsonProperty("is_author")]
		public bool IsAuthor { get; set; }
	}

	/// <summary>
	/// Represents a Geeklist card contributor.
	/// </summary>
	/// <author>Scott Smith</author>
	
	public class Contributor
	{
		[JsonProperty("screen_name")]
		public string ScreenName { get; set; }

		[JsonProperty("screen_name_upper")]
		public string ScreenNameUpper { get; set; }

		[JsonProperty("avatar")]
		public Avatar Avatar { get; set; }

		[JsonProperty("social")]
		public Social Social { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
