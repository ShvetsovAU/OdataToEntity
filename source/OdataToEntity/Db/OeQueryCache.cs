﻿using Microsoft.OData.UriParser;
using OdataToEntity.Parsers;
using OdataToEntity.Parsers.UriCompare;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OdataToEntity.Db
{
    public sealed class QueryCacheItem
    {
        private readonly Expression _countExpression;
        private readonly OeEntryFactory _entryFactory;
        private readonly Object _query;

        public QueryCacheItem(Object query, Expression countExpression, OeEntryFactory entryFactory)
        {
            _query = query;
            _countExpression = countExpression;
            _entryFactory = entryFactory;
        }

        public Expression CountExpression => _countExpression;
        public OeEntryFactory EntryFactory => _entryFactory;
        public Object Query => _query;
    }

    public sealed class OeQueryCache
    {
        private readonly ConcurrentDictionary<OeParseUriContext, QueryCacheItem> _cache;

        public OeQueryCache()
        {
            _cache = new ConcurrentDictionary<OeParseUriContext, QueryCacheItem>(new OeParseUriContextEqualityComparer());
            AllowCache = true;
        }

        public void AddQuery(OeParseUriContext parseUriContext, Object query, Expression countExpression,
            IReadOnlyDictionary<ConstantNode, OeQueryCacheDbParameterDefinition> constantNodeNames)
        {
            parseUriContext.ConstantToParameterMapper = constantNodeNames;
            var queryCacheItem = new QueryCacheItem(query, countExpression, parseUriContext.EntryFactory);
            _cache.TryAdd(parseUriContext, queryCacheItem);
        }
        public QueryCacheItem GetQuery(OeParseUriContext parseUriContext)
        {
            QueryCacheItem cacheItem;
            _cache.TryGetValue(parseUriContext, out cacheItem);
            return cacheItem;
        }

        public bool AllowCache { get; set; }
        public int CacheCount => _cache.Count;
    }
}
