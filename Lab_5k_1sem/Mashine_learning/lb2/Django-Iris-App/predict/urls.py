from django.urls import path
from . import views

app_name = "predict"

urlpatterns = [
    path('', views.predict, name='prediction_page'),
    path('predict/', views.predict_chances, name='submit_prediction'),
    path('results/', views.view_results, name='results'),
    path('trainpage/', views.train_page, name='train_page'),
    path('trainmodel/', views.train_model, name='train_model'),
]