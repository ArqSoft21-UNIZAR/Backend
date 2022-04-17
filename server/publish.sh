#!/bin/bash

heroku container:login
docker build -t meetme-b .
heroku container:push -a meetme-b web
heroku container:release -a meetme-b web
