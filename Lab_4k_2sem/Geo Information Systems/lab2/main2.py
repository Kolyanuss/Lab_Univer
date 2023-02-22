import osgeo.ogr
from stufFunc import printLayers

shapefile = osgeo.ogr.Open("resource/gis_osm_roads_free_1.shp")
numLayers = shapefile.GetLayerCount()
printLayers(numLayers, shapefile)

road_layer  = shapefile.GetLayer()

total_length = 0

for feature in road_layer:
    geometry = feature.GetGeometryRef()
    length = geometry.Length()
    total_length += length

print(f'Total road length: {total_length}')
