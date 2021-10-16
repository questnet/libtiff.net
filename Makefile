.PHONY: all
all: 
	@echo Take a look at the Makefile to find out more.

.PHONY: publish-lib
publish-lib: 
	rm -f Tiff2PdfLib/bin/Release/*.nupkg
	dotnet clean -c Release Tiff2PdfLib 
	dotnet pack -c Release Tiff2PdfLib
	dotnet nuget push Tiff2PdfLib/bin/Release/Tiff2PdfLib.*.nupkg --source ${QUESTNET_PACKAGES_NUGET_SOURCE} --api-key ${QUESTNET_PACKAGES_PUSH_API_KEY}

