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

def getByFilter(request):
    selected_option_amentity = request.GET.get("typeAmenity")
    
    if selected_option_amentity == None:
        return HttpResponse("Error 404 Amenity not found")
    # print(selected_option_amentity)
    
    selected_option_shop = ""
    if selected_option_amentity == "shop":
        selected_option_shop = request.GET.get("typeShop")
        if selected_option_shop == None:
            return HttpResponse("Error 404 Shop not found")
        # print(selected_option_shop)

    listResult = []
    table_name = "che_point_amenity"
    column_name = "amenity"
    condition = selected_option_amentity
    if selected_option_shop != "":
        table_name = "che_point_shop"
        column_name = "shop"
        condition = selected_option_shop

    listResult = che_point_shop.objects.raw(f"SELECT * FROM {table_name} WHERE {column_name} = '{condition}'") # fix this
    print(listResult)

    return render(request, "list.html", {"items": listResult})

def showMap(request):
    selected_option_amentity = request.GET.get("typeAmenity")
    
    if selected_option_amentity == None:
        return HttpResponse("Error 404 Amenity not found")
    print(selected_option_amentity)
    
    selected_option_shop = ""
    if selected_option_amentity == "shop":
        selected_option_shop = request.GET.get("typeShop")
        if selected_option_shop == None:
            return HttpResponse("Error 404 Shop not found")
        print(selected_option_shop)

    # radius = request.GET.get("radius")
    # if radius != None:
    return HttpResponse(selected_option_amentity+" - "+selected_option_shop)

def testMap(request):
    return render(request, "testMap.html")