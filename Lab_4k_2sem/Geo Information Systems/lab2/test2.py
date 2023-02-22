import osgeo.ogr

shapefile = osgeo.ogr.Open("resource/gis_osm_roads_free_1.shp")
road_layer  = shapefile.GetLayer()

total_length = 0

for feature in road_layer:
    fieldCount = feature.GetFieldCount()
    for fieldId in range(fieldCount):
        print(feature.GetFieldDefnRef(fieldId).GetAlternativeNameRef())
        print(feature.GetField(fieldId))
        print("----")
    geometry = feature.GetGeometryRef()
    length = geometry.Length()
    total_length += length
    break

print(f'Total road length: {total_length}')