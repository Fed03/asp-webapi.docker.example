API_NODE_PATH:=../

N?=0
.PHONY: build-N
build-N:
	docker build --file ./Dockerfile.${N} \
		-t api-node:${N} \
		${API_NODE_PATH}

.PHONY: build-all
build-all:
	for number in 0 1 2 3 4 5 6 7 8; do \
			N=$$number $(MAKE) build-N; \
	done