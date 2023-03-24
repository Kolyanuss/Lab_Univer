from django.shortcuts import render
from django.contrib.gis.geos import Point
from django.http import HttpResponse
from myapp.models import che_point_shop
from myapp.models import che_point_amenity
from django.contrib.gis.db.models.functions import Distance



def _convertCorruptedTextToNormal(CorruptedList):
    for item in CorruptedList:
        if item.name != None:
            item.name = item.name.encode("latin-1").decode("cp1251")


def renderMainPage(request):
    return render(request, "index.html", {"AmenityItems": getTypeOfAmenity(), "ShopItems": getTypeOfShops()})


def getAllShops(request):
    List = che_point_shop.objects.all()
    _convertCorruptedTextToNormal(List)
    return render(request, "list.html", {"items": List})


def getAllAmenity(request):
    List = che_point_amenity.objects.all()
    _convertCorruptedTextToNormal(List)
    return render(request, "list.html", {"items": List})


def mapAllShops(request):
    List = che_point_shop.objects.all()
    _convertCorruptedTextToNormal(List)
    return render(request, "map.html", {"items": List, "model_type": "shop"})


def mapAllAmenity(request):
    List = che_point_amenity.objects.all()
    _convertCorruptedTextToNormal(List)
    return render(request, "map.html", {"items": List, "model_type": "amenity"})


def getTypeOfShops():
    List = che_point_shop.objects.values('shop').distinct()
    ListStringNames = []
    for item in List:
        ListStringNames.append(item['shop'])
    return ListStringNames


def getTypeOfAmenity():
    List = che_point_amenity.objects.values('amenity').distinct()
    ListStringNames = []
    for item in List:
        ListStringNames.append(item['amenity'])
    return ListStringNames


def _myFilter(request):
    selected_option_amentity = request.GET.get("typeAmenity")

    if selected_option_amentity == None:
        return HttpResponse("Error 404 Amenity not found")

    selected_option_shop = ""
    if selected_option_amentity == "shop":
        selected_option_shop = request.GET.get("typeShop")
        if selected_option_shop == None:
            return HttpResponse("Error 404 Shop not found")

    listResult = []
    if selected_option_shop != "":
        listResult = che_point_shop.objects.filter(shop=selected_option_shop)
    else:
        listResult = che_point_amenity.objects.filter(
            amenity=selected_option_amentity)
    _convertCorruptedTextToNormal(listResult)

    return listResult


def _getByFilter(request):
    listResult = _myFilter(request)
    return render(request, "list.html", {"items": listResult})


def _mapByFilter(request):
    listResult = _myFilter(request)
    return render(request, "map.html", {"items": listResult})


def searchByFilter(request):
    if '_list' in request.GET:
        return _getByFilter(request)
    elif '_map' in request.GET:
        return _mapByFilter(request)


def searchByRadius(request):
    pointInfo = request.GET.get('pointInfo')
    radius = request.GET.get('radius')
    lat,lng,model_type = pointInfo.split(', ')
    lat,lng = float(lat),float(lng)

    user_location = Point(lng, lat, srid=4326)
    if (model_type == "amenity"):
        model = che_point_amenity
    else:
        model = che_point_shop
    listResult = model.objects.annotate(distance=Distance('geometry', user_location)).filter(distance__lt=radius).order_by('distance')
    _convertCorruptedTextToNormal(listResult)
    return render(request, "map.html", {"items": listResult})
