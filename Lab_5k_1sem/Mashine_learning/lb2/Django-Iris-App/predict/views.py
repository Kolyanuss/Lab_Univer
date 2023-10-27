from django.shortcuts import render
from django.http import JsonResponse
import pandas as pd
from .models import PredResults
from .train_iris import train_new_model
from django.conf import settings

def predict(request):
    return render(request, 'predict.html')


def predict_chances(request):
    if request.POST.get('action') == 'post':
        sepal_length = request.POST.get('sepal_length')
        sepal_width = request.POST.get('sepal_width')
        petal_length = request.POST.get('petal_length')
        petal_width = request.POST.get('petal_width')

        sepal_length = float(sepal_length) if sepal_length != '' else -1
        sepal_width = float(sepal_width) if sepal_width != '' else -1
        petal_length = float(petal_length) if petal_length != '' else -1
        petal_width = float(petal_width) if petal_width != '' else -1

        active_feature = []
        if settings.ACTIVE_FEATURE[0]:
            active_feature.append(sepal_length)
        if settings.ACTIVE_FEATURE[1]:
            active_feature.append(sepal_width)
        if settings.ACTIVE_FEATURE[2]:
            active_feature.append(petal_length)
        if settings.ACTIVE_FEATURE[3]:
            active_feature.append(petal_width)

        # Unpickle model
        model = pd.read_pickle(settings.ML_MODEL)
        # Make prediction
        result = model.predict([active_feature])

        classification = result[0]

        PredResults.objects.create(sepal_length=sepal_length, sepal_width=sepal_width, petal_length=petal_length,
                                   petal_width=petal_width, classification=classification)

        return JsonResponse({'result': classification, 
                             'sepal_length': sepal_length,
                             'sepal_width': sepal_width, 
                             'petal_length': petal_length, 
                             'petal_width': petal_width},
                            safe=False)


def view_results(request):
    # Submit prediction and show all
    data = {"dataset": PredResults.objects.all()}
    return render(request, "results.html", data)


def train_page(request):
    return render(request, 'train_page.html')


def train_model(request):
    if request.POST.get('action') == 'post':
        # Receive data from client
        pr1 = True if request.POST.get('sepal_length') == "true" else False
        pr2 = True if request.POST.get('sepal_width') == "true" else False
        pr3 = True if request.POST.get('petal_length') == "true" else False
        pr4 = True if request.POST.get('petal_width') == "true" else False
        settings.ACTIVE_FEATURE = [pr1,pr2,pr3,pr4]
        train_new_model(pr1,pr2,pr3,pr4)
        return JsonResponse({'result': "Success!"}, safe=False)