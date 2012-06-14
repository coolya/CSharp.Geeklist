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
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Models
{
	/// <summary>
	/// Represents a Geeklist trending history.
	/// </summary>
	/// <author>Scott Smith</author>
	
	public class TrendingHistory
	{
		[JsonProperty("trending_at")]
		public string TrendingAt { get; set; }

		[JsonProperty("trending_by")]
		public string TrendingBy { get; set; }

		[JsonProperty("_id")]
		public string Id { get; set; }
	}
}
