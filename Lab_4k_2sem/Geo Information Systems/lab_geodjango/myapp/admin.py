from django.contrib import admin
from django.contrib.gis.admin import OSMGeoAdmin
from .models import che_point_amenity,che_point_shop

@admin.register(che_point_amenity)
class AmenityAdmin(OSMGeoAdmin):
    list_display = ('name', 'amenity', 'geometry')
    
@admin.register(che_point_shop)
class ShopAdmin(OSMGeoAdmin):
    list_display = ('name', 'shop', 'geometry')
