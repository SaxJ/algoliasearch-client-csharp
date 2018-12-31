﻿/*
* Copyright (c) 2018 Algolia
* http://www.algolia.com/
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using Algolia.Search.Http;
using Algolia.Search.Models.ApiKeys;
using Algolia.Search.Models.Batch;
using Algolia.Search.Models.Common;
using Algolia.Search.Models.Mcm;
using Algolia.Search.Models.Personalization;
using Algolia.Search.Models.Search;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Algolia.Search.Clients
{
    /// <summary>
    /// Search Client interface
    /// </summary>
    public interface ISearchClient
    {
        /// <summary>
        /// Initialize an index for the given client
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        SearchIndex InitIndex(string indexName);

        /// <summary>
        /// Retrieve one or more objects, potentially from different indices, in a single API call.
        /// </summary>
        /// <typeparam name="T">Type of the data to send/retrieve</typeparam>
        MultipleGetObjectsResponse<T> MultipleGetObjects<T>(IEnumerable<MultipleGetObject> queries,
            RequestOptions requestOptions = null) where T : class;

        /// <summary>
        /// Retrieve one or more objects, potentially from different indices, in a single API call.
        /// </summary>
        /// <typeparam name="T">Type of the data to send/retrieve</typeparam>
        Task<MultipleGetObjectsResponse<T>> MultipleGetObjectsAsync<T>(
            IEnumerable<MultipleGetObject> queries,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken)) where T : class;

        /// <summary>
        /// This method allows to send multiple search queries, potentially targeting multiple indices, in a single API call.
        /// </summary>
        /// <typeparam name="T">Type of the data to send/retrieve</typeparam>
        MultipleQueriesResponse<T> MultipleQueries<T>(MultipleQueriesRequest request,
            RequestOptions requestOptions = null) where T : class;

        /// <summary>
        /// This method allows to send multiple search queries, potentially targeting multiple indices, in a single API call.
        /// </summary>
        /// <typeparam name="T">Type of the data to send/retrieve</typeparam>
        Task<MultipleQueriesResponse<T>> MultipleQueriesAsync<T>(MultipleQueriesRequest request,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken)) where T : class;

        /// <summary>
        /// Perform multiple write operations, potentially targeting multiple indices, in a single API call.
        /// </summary>
        /// <typeparam name="T">Type of the data to send/retrieve</typeparam>
        MultipleIndexBatchIndexingResponse MultipleBatch<T>(IEnumerable<BatchOperation<T>> operations,
            RequestOptions requestOptions = null) where T : class;

        /// <inheritdoc />
        /// <summary>
        /// Perform multiple write operations, potentially targeting multiple indices, in a single API call.
        /// </summary>
        /// <typeparam name="T">Type of the data to send/retrieve</typeparam>
        Task<MultipleIndexBatchIndexingResponse> MultipleBatchAsync<T>(
            IEnumerable<BatchOperation<T>> operations, RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken)) where T : class;

        /// <summary>
        /// Get a list of indexes/indices with their associated metadata.
        /// </summary>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        ListIndicesResponse ListIndices(RequestOptions requestOptions = null);

        /// <summary>
        /// Get a list of indexes/indices with their associated metadata.
        /// </summary>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<ListIndicesResponse> ListIndicesAsync(RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Delete an index and all its settings, including links to its replicas.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        DeleteResponse DeleteIndex(string indexName, RequestOptions requestOptions = null);

        /// <summary>
        /// Delete an index and all its settings, including links to its replicas.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<DeleteResponse> DeleteIndexAsync(string indexName, RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Generate a virtual API Key without any call to the server.
        /// </summary>
        /// <param name="parentApiKey"></param>
        /// <param name="restriction"></param>
        /// <returns></returns>
        string GenerateSecuredApiKeys(string parentApiKey, SecuredApiKeyRestriction restriction);

        /// <summary>
        /// Get the full list of API Keys.
        /// </summary>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        ListApiKeysResponse ListApiKeys(RequestOptions requestOptions = null);

        /// <summary>
        /// Get the full list of API Keys.
        /// </summary>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<ListApiKeysResponse> ListApiKeysAsync(RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Get the permissions of an API Key.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        ApiKey GetApiKey(string apiKey, RequestOptions requestOptions = null);

        /// <summary>
        /// Get the permissions of an API Key.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<ApiKey> GetApiKeyAsync(string apiKey, RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Add a new API Key with specific permissions/restrictions.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        AddApiKeyResponse AddApiKey(ApiKey apiKey, RequestOptions requestOptions = null);

        /// <summary>
        /// Add a new API Key with specific permissions/restrictions.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<AddApiKeyResponse> AddApiKeyAsync(ApiKey apiKey, RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Update the permissions of an existing API Key.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        UpdateApiKeyResponse UpdateApiKey(ApiKey request, RequestOptions requestOptions = null);

        /// <summary>
        /// Update the permissions of an existing API Key.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<UpdateApiKeyResponse> UpdateApiKeyAsync(ApiKey request,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Delete an existing API Key
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        DeleteApiKeyResponse DeleteApiKey(string apiKey, RequestOptions requestOptions = null);

        /// <summary>
        /// Delete an existing API Key
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<DeleteApiKeyResponse> DeleteApiKeyAsync(string apiKey, RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// List the clusters available in a multi-clusters setup for a single appID
        /// </summary>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        IEnumerable<ClustersResponse> ListClusters(RequestOptions requestOptions = null);

        /// <summary>
        /// List the clusters available in a multi-clusters setup for a single appID
        /// </summary>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<IEnumerable<ClustersResponse>> ListClustersAsync(RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Search for userIDs
        /// The data returned will usually be a few seconds behind real-time, because userID usage may take up to a few seconds propagate to the different cluster
        /// </summary>
        /// <param name="query"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        SearchResponse<UserIdResponse> SearchUserIDs(SearchUserIdsRequest query,
            RequestOptions requestOptions = null);

        /// <summary>
        /// Search for userIDs
        /// The data returned will usually be a few seconds behind real-time, because userID usage may take up to a few seconds propagate to the different cluster
        /// </summary>
        /// <param name="query"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<SearchResponse<UserIdResponse>> SearchUserIDsAsync(SearchUserIdsRequest query,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// List the userIDs assigned to a multi-clusters appID.
        /// </summary>
        /// <param name="hitsPerPage"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="page"></param>
        /// <returns></returns>
        ListUserIdsResponse ListUserIds(int page = 0, int hitsPerPage = 1000,
            RequestOptions requestOptions = null);

        /// <summary>
        /// List the userIDs assigned to a multi-clusters appID.
        /// </summary>
        /// <param name="hitsPerPage"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<ListUserIdsResponse> ListUserIdsAsync(int page = 0, int hitsPerPage = 1000,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Returns the userID data stored in the mapping.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        UserIdResponse GetUserId(string userId, RequestOptions requestOptions = null);

        /// <summary>
        /// Returns the userID data stored in the mapping.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<UserIdResponse> GetUserIdAsync(string userId, RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Get the top 10 userIDs with the highest number of records per cluster.
        /// The data returned will usually be a few seconds behind real-time, because userID usage may take up to a few seconds to propagate to the different clusters.
        /// </summary>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        TopUserIdResponse GetTopUserId(RequestOptions requestOptions = null);

        /// <summary>
        /// Get the top 10 userIDs with the highest number of records per cluster.
        /// The data returned will usually be a few seconds behind real-time, because userID usage may take up to a few seconds to propagate to the different clusters.
        /// </summary>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<TopUserIdResponse> GetTopUserIdAsync(RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Assign or Move a userID to a cluster.
        /// The time it takes to migrate (move) a user is proportional to the amount of data linked to the userID.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clusterName"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        AssignUserIdResponse
            AssignUserId(string userId, string clusterName, RequestOptions requestOptions = null);

        /// <summary>
        /// Assign or Move a userID to a cluster.
        /// The time it takes to migrate (move) a user is proportional to the amount of data linked to the userID.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clusterName"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<AssignUserIdResponse> AssignUserIdAsync(string userId, string clusterName,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Remove a userID and its associated data from the multi-clusters.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        RemoveUserIdResponse RemoveUserId(string userId, RequestOptions requestOptions = null);

        /// <summary>
        /// Remove a userID and its associated data from the multi-clusters.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<RemoveUserIdResponse> RemoveUserIdAsync(string userId, RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Get the logs of the latest search and indexing operations
        /// You can retrieve the logs of your last 1,000 API calls. It is designed for immediate, real-time debugging.
        /// </summary>
        /// <returns></returns>
        LogResponse GetLogs(RequestOptions requestOptions = null, int offset = 0, int length = 10,
            string indexName = null, string type = "all");

        /// <summary>
        /// Get the logs of the latest search and indexing operations
        /// You can retrieve the logs of your last 1,000 API calls. It is designed for immediate, real-time debugging.
        /// </summary>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="indexName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<LogResponse> GetLogsAsync(RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken), int offset = 0, int length = 10, string indexName = null,
            string type = "all");

        /// <summary>
        /// Copy the settings of an index to another index
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        CopyToResponse CopySettings(string sourceIndex, string destinationIndex,
            RequestOptions requestOptions = null);

        /// <summary>
        /// Copy the settings of an index to another index
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<CopyToResponse> CopySettingsAsync(string sourceIndex, string destinationIndex,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Copy the rules of an index to another index
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        CopyToResponse CopyRules(string sourceIndex, string destinationIndex,
            RequestOptions requestOptions = null);

        /// <summary>
        /// Copy the rules of an index to another index
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<CopyToResponse> CopyRulesAsync(string sourceIndex, string destinationIndex,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Make a copy of the synonyms of an index
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        CopyToResponse CopySynonyms(string sourceIndex, string destinationIndex,
            RequestOptions requestOptions = null);

        /// <summary>
        /// Make a copy of the synonyms of an index
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<CopyToResponse> CopySynonymsAsync(string sourceIndex, string destinationIndex,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Make a copy of an index, including its objects, settings, synonyms, and query rules.
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="scope">The scope copy</param>
        /// <returns></returns>
        CopyToResponse CopyIndex(string sourceIndex, string destinationIndex, RequestOptions requestOptions = null,
            IEnumerable<string> scope = null);

        /// <summary>
        /// Make a copy of an index, including its objects, settings, synonyms, and query rules.
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <param name="scope">The scope copy</param>
        /// <returns></returns>
        Task<CopyToResponse> CopyIndexAsync(string sourceIndex, string destinationIndex,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken),
            IEnumerable<string> scope = null);

        /// <summary>
        /// Rename an index. Normally used to reindex your data atomically, without any down time.
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <returns></returns>
        MoveIndexResponse MoveIndex(string sourceIndex, string destinationIndex,
            RequestOptions requestOptions = null);

        /// <summary>
        /// Rename an index. Normally used to reindex your data atomically, without any down time.
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationIndex">The destination index</param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        /// <param name="ct">Optional cancellation token</param>
        /// <returns></returns>
        Task<MoveIndexResponse> MoveIndexAsync(string sourceIndex, string destinationIndex,
            RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Returns the personalization strategy of the application
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns></returns>
        GetStrategyResponse GetPersonalizationStrategy(RequestOptions requestOptions = null);

        /// <summary>
        /// Returns the personalization strategy of the application
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <param name="ct">Optional cancellation token</param>
        Task<GetStrategyResponse> GetPersonalizationStrategyAsync(RequestOptions requestOptions = null,
            CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// This command configures the personalization strategy
        /// </summary>
        /// <param name="request">The personalization strategy</param>
        /// <param name="requestOptions">Request options for the query</param>
        /// <returns></returns>
        SetStrategyResponse
            SetPersonalizationStrategy(SetStrategyRequest request, RequestOptions requestOptions = null);

        /// <summary>
        /// This command configures the personalization strategy
        /// </summary>
        /// <param name="request">The personalization strategy></param>
        /// <param name="requestOptions">Request options for the query</param>
        /// <param name="ct">Request options for the query</param>
        /// <returns></returns>
        Task<SetStrategyResponse> SetPersonalizationStrategyAsync(SetStrategyRequest request,
            RequestOptions requestOptions = null, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// This function waits for the Algolia's API task to finish
        /// </summary>
        /// <param name="indexName">Your index name</param>
        /// <param name="taskId">taskID returned by Aloglia API</param>
        /// <param name="timeToWait"></param>
        /// <param name="requestOptions">Add extra http header or query parameters to Algolia</param>
        void WaitTask(string indexName, long taskId, int timeToWait = 100, RequestOptions requestOptions = null);
    }
}