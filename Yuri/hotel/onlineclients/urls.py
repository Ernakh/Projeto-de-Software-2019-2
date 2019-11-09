from django.conf.urls import url

from onlineclients.views import PessoaListView

from . import views

urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^list/$', PessoaListView.as_view(), name='pessoa_list'),
]