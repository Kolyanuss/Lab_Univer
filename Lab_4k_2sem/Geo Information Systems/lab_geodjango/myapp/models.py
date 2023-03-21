from django.contrib.gis.db import models

class che_point_amenity(models.Model):
    name = models.CharField(max_length=100)
    amenity = models.CharField(max_length=100)
    geometry = models.PointField()

class che_point_shop(models.Model):
    name = models.CharField(max_length=100)
    shop = models.CharField(max_length=100)
    geometry = models.PointField()
