# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.views.generic.list import ListView

from django.shortcuts import render
from django.http import HttpResponse

from onlineclients.models import Pessoa
from django.utils import timezone

# Create your views here.

def index(request):
    return render(request, 'onlineclients/index.html')

class PessoaListView(ListView):

	model = Pessoa

	def get_context_data(self, **kwargs):
		context = super(PessoaListView, self).get_context_data(**kwargs)

		context['now'] = timezone.now()

		return context