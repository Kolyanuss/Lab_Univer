from django.shortcuts import render
from django.contrib.gis.geos import Point
from django.http import HttpResponse
from myapp.models import che_point_shop

# def location(request):
#     locations = Location.objects.filter(point__distance_lte=(Point(-73.98, 40.77), 10000))
#     return render(request, 'location.html', {'locations': locations})


def renderMainPage(request):
    return render(request, "base.html")


def getAllShops(request):
    shopList = [che_point_shop(name="name1")]
    return render(request, "list.html", {"items": shopList})
