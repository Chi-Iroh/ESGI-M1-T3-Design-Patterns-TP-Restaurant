SHELL := /bin/bash

all:
	dotnet publish -c Release --self-contained true /p:PublishSingleFile=true --output .
