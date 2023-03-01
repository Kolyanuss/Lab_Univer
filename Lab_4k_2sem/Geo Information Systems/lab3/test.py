import rasterio
import geopandas as gpd 
import earthpy.plot as ep
import earthpy.spatial as es 
import matplotlib.pyplot as plt

# Open the TIF file using rasterio
# with rasterio.open('LC81830262015142LGN00\LC81830262015142LGN00_B11.TIF') as src:
with rasterio.open('2015-04-11_LC81840262015101LGN00\LC81840262015101LGN00_B5.TIF') as src:
    tif_file = src.read()

# Plot the TIF file using EarthPy
# ep.plot_rgb(tif_file)
# ep.plot_bands(tif_file[0],
#               title="Landsat Band",
#               scale=False)
# plt.show()

    from shapely.geometry import Polygon
    d = {'geometry': [Polygon([(25.81, 48.35), (26.07, 48.34), (26.09, 48.23), (25.81, 48.23), (25.81, 48.35)])]}
    crop_gdf = gpd.GeoDataFrame(d, crs="EPSG:4326")
    # Open a single band and plot

    # Reproject the fire boundary shapefile to be the same CRS as the Landsat data
    crop_raster_profile = src.profile
    fire_boundary_utmz13 = crop_gdf.to_crs(crop_raster_profile["crs"])
    # Crop the landsat image to the extent of the fire boundary
    landsat_band4, landsat_metadata = es.crop_image(src, fire_boundary_utmz13)
    
ep.plot_bands(landsat_band4[0],
              title="Landsat Cropped Band",
              scale=False)
plt.show()
