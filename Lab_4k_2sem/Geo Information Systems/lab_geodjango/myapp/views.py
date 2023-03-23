from django.shortcuts import render
from django.contrib.gis.geos import Point
from django.http import HttpResponse
from myapp.models import che_point_shop
from myapp.models import che_point_amenity

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
    return render(request, "map.html", {"items": List})

def mapAllAmenity(request):
    List = che_point_amenity.objects.all()
    _convertCorruptedTextToNormal(List)
    return render(request, "map.html", {"items": List})

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
        listResult = che_point_amenity.objects.filter(amenity=selected_option_amentity)
    _convertCorruptedTextToNormal(listResult)

    return listResult

def getByFilter(request):
    listResult = _myFilter(request)
    return render(request, "list.html", {"items": listResult})

def mapByFilter(request):
    listResult = _myFilter(request)
    return render(request, "map.html", {"items": listResult})

def testMap(request):
    return render(request, "testMap.html")