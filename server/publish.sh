#!/bin/bash

set -x
docker build ./. --pull -f ./Dockerfile -t registry.heroku.com/meetme-b/web
docker push registry.heroku.com/meetme-b/web
heroku container:release web -a meetme-b
