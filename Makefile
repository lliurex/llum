
SOURCES=	llum/*.cs						\
		llum/gtk-gui/*.cs
		
	
CSC = dmcs
CSC_FLAGS = -r:Mono.Posix.dll -pkg:gtk-sharp-2.0 -pkg:xmlrpcnet -pkg:libnewtonsoft-json5.0-cil -r:libmono-lliurex-utils -optimize+
OUT = llum.exe
PKG_CONFIG_PATH = "/usr/lib/pkgconfig"

RESOURCE = rsrc/watch.gif,llum.watch.gif
RESOURCE2 = rsrc/llum.svg,llum.llum.svg

NO_COLOR    = \x1b[0m
COMPILE_COLOR    = \x1b[32;01m
LINK_COLOR    = \x1b[31;01m

clean: 
	rm -rf bin/
	rm -f lliurex-control-center.pidb
	@echo -e '$(LINK_COLOR)* Cleaning [$@]$(NO_COLOR)'
	@$(MAKE) -C banners-rsrc/ $@

banners:
	@echo -e '$(LINK_COLOR)* Building [$@]$(NO_COLOR)'
	@$(MAKE) -C banners-rsrc/ -j2 $@
	
banners-clean:
	@echo -e '$(LINK_COLOR)* Cleaning [$@]$(NO_COLOR)'
	@$(MAKE) -C banners-rsrc/ $@
	


release: $(SOURCES)
	mkdir -p bin/Release/
	LC_CTYPE=C.UTF-8 $(CSC) $(CSC_FLAGS) $(SOURCES) -resource:$(RESOURCE) -resource:$(RESOURCE2) -out:bin/Release/$(OUT)
	
	
	
debug: $(SOURCES)
	mkdir -p bin/Debug/
	$(CSC) $(CSC_FLAGS) $(SOURCES) -resource:$(RESOURCE) -resource:$(RESOURCE2) -out:bin/Debug/$(OUT)	 -debug
