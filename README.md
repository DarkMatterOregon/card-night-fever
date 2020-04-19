# card-night-fever
Where do you go when the dealing's done?

## Run the App From Docker

### Install the image and container

- Install Docker
- Build the image with `docker build -t card-night-fever:1.0.0 .`

### Run the app
- Run the image with `docker run -p 5000:8080 card-night-fever:1.0.0`
- Open a browser and go to `localhost:5000`

### Close down the app
 Stop the app using ctl+c.

## Run the App From Kubernetes

### Install Kubernetes
- Look online to find how to install at least a single node k8s cluster.
- There are many ways to run k8s, including KinD, microk8s, and others.

### Create the namespaces, apply deployments and services

Run the following commands:

```bash
    $ kubectl create namespace card-night-fever-stage
    $ kubectl create namespace card-night-fever-prod
    $ kubectl apply -f ./kube
```

### Run the app
- Wait for the pod to be deployed. You can see if the pod is running with `kubectl get pods -n card-night-fever`
- See which IP address the app is running on with `kubectl get service -n card-night-fever`. Take note of the `CLUSTER_IP`.
- Open a browser and point to the `CLUSTER_IP` address. It will automatically be using port 80, so no port need be specified.
- Go to cluster IP on your browser, e.g. `http://10.0.0.1/`, to run the app

### Shut down app
- `kubectl delete namespace card-night-fever-stage`
- `kubectl delete namespace card-night-fever-prod`
