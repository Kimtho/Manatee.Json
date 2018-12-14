﻿using System;
using System.Collections.Generic;

namespace Manatee.Json.Schema
{
	/// <summary>
	/// Represents a draft-08 schema vocabulary.
	/// </summary>
	public class SchemaVocabulary
	{
		/// <summary>
		/// Gets the vocabulary ID.
		/// </summary>
		public string Id { get; }
		/// <summary>
		/// Gets the ID of the meta-schema associated with the vocabulary.
		/// </summary>
		public string MetaSchemaId { get; }

		internal List<Type> DefinedKeywords { get; } = new List<Type>();

		/// <summary>
		/// Creates a new instance of the <see cref="SchemaVocabulary"/> class.
		/// </summary>
		public SchemaVocabulary(string id, string metaSchemaId)
		{
			Id = id;
			MetaSchemaId = metaSchemaId;
		}
		internal SchemaVocabulary(string id)
		{
			Id = id;
		}
	}
}
