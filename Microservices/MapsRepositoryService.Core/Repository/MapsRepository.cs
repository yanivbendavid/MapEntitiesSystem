﻿using MapsRepositoryService.Core.Model;
using MapsRepositoryService.Core.Repository.Commands;
using MapsRepositoryService.Core.Repository.Queries;

namespace MapsRepositoryService.Core.Repository;
public class MapsRepository : IMapsRepository
{
    private readonly IGetMapDataQuery _getMapDataQuery;
    private readonly IGetMapsNamesQuery _getMapsNamesQuery;
    private readonly IAddMapCommand _addMapCommand;
    private readonly IDeleteMapCommand _deleteMapCommand;

    public MapsRepository(IGetMapDataQuery getMapDataQuery, 
                          IGetMapsNamesQuery getMapsNamesQuery,
                          IAddMapCommand addMapCommand,
                          IDeleteMapCommand deleteMapCommand)
    {
        _getMapDataQuery = getMapDataQuery;
        _getMapsNamesQuery = getMapsNamesQuery;
        _addMapCommand = addMapCommand;
        _deleteMapCommand = deleteMapCommand;
    }

    public Task<MapResultModel> GetMapDataAsync(string mapName) => _getMapDataQuery.GetMapByNameAsync(mapName);

    public Task<MapNamesResultModel> GetMapsNamesAsync() => _getMapsNamesQuery.GetMapsNamesAsync();

    public Task<ResultModel> AddMapAsync(MapModel mapModel) => _addMapCommand.AddMapAsync(mapModel);

    public Task<ResultModel> DeleteMapAsync(string mapName) => _deleteMapCommand.DeleteMapAsync(mapName);
    public bool IsMapNameExits(string mapName)
    {
        var names = _getMapsNamesQuery.GetMapsNamesAsync();
        throw new NotImplementedException();
    }
}
