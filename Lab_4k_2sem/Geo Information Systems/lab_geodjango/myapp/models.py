from django.contrib.gis.db import models

class che_point_amenity(models.Model):
    name = models.CharField(max_length=100)
    amenity = models.CharField(max_length=100)
    geometry = models.PointField(srid=4326)
    
    def __str__(self):
        return "{} | {}".format(self.amenity, self.name)
    
    class Meta:
        db_table = 'che_point_amenity'

class che_point_shop(models.Model):
    name = models.CharField(max_length=100)
    shop = models.CharField(max_length=100)
    geometry = models.PointField(srid=4326)
    
    def __str__(self):
        return "{} | {}".format(self.shop, self.name)
    
    class Meta:
        db_table = 'che_point_shops'
