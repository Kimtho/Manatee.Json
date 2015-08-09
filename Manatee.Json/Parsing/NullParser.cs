﻿/***************************************************************************************

	Copyright 2015 Greg Dennis

	   Licensed under the Apache License, Version 2.0 (the "License");
	   you may not use this file except in compliance with the License.
	   You may obtain a copy of the License at

		 http://www.apache.org/licenses/LICENSE-2.0

	   Unless required by applicable law or agreed to in writing, software
	   distributed under the License is distributed on an "AS IS" BASIS,
	   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	   See the License for the specific language governing permissions and
	   limitations under the License.
 
	File Name:		NullParser.cs
	Namespace:		Manatee.Json.Parsing
	Class Name:		NullParser
	Purpose:		Parses JSON null.

***************************************************************************************/
using Manatee.Json.Internal;

namespace Manatee.Json.Parsing
{
	internal class NullParser : IJsonParser
	{
		public bool Handles(char c)
		{
			return c.In('n', 'N');
		}
		public string TryParse(string source, ref int index, out JsonValue value)
		{
			var buffer = new char[4];
			for (int i = 0; i < 4 && index + i < source.Length; i++)
			{
				buffer[i] = source[index + i];
			}
			var result = new string(buffer).ToLower();
			if (result != "null")
			{
				value = null;
				return string.Format("Value not recognized: '{0}'", result);
			}
			index += 4;
			value = JsonValue.Null;
			return null;
		}
	}
}