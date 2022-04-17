#!/bin/bash

set -x
docker build -t meetme
docker tag meetme registry.heroku.com/meetme-b/web
docker push registry.heroku.com/meetme-b/web
heroku container:release web -a meetme-b
