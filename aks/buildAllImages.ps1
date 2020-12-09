Param(
    # api docker Image Tag
    [Parameter(Mandatory=$false)][string]$mortgagefixedratesImageTag,
    [Parameter(Mandatory=$false)][string]$mortgagevariableratesImageTag,
    [Parameter(Mandatory=$false)][string]$mortgagerateaveragesImageTag,
    [Parameter(Mandatory=$false)][string]$mortgageuiImageTag
)

if ([string]::IsNullOrEmpty($mortgagefixedratesImageTag)) {
    $mortgagefixedratesImageTag = 'latest'
}
Write-Host "Docker mortgagefixedrates image will be built with tag: $mortgagefixedratesImageTag" -ForegroundColor White


if ([string]::IsNullOrEmpty($mortgagevariableratesImageTag)) {
    $mortgagevariableratesImageTag = 'latest'
}
Write-Host "Docker mortgagevariablerates image will be built with tag: $mortgagevariableratesImageTag" -ForegroundColor White


if ([string]::IsNullOrEmpty($mortgagerateaveragesImageTag)) {
    $mortgagerateaveragesImageTag = 'latest'
}
Write-Host "Docker mortgagerateaverages image will be built with tag: $mortgagerateaveragesImageTag" -ForegroundColor White

if ([string]::IsNullOrEmpty($mortgageuiImageTag)) {
    $mortgageuiImageTag = 'latest'
}
Write-Host "Docker mortgageui image will be built with tag: $mortgageuiImageTag" -ForegroundColor White

docker build -t mortgagefixedrates:$mortgagefixedratesImageTag ../mortgage.fixedrates
docker build -t mortgagevariablerates:$mortgagevariableratesImageTag ../mortgage.variablerates
docker build -t mortgagerateaverages:$mortgagerateaveragesImageTag ../mortgage.variablerates
docker build -t mortgageui:$mortgageuiImageTag ../mortgageui
docker image ls "mortgage*"

$acrName = "iliasjmortgageappcr"
docker tag  mortgagefixedrates:$mortgagefixedratesImageTag "$acrName.azurecr.io/mortgagefixedrates:$mortgagefixedratesImageTag"
docker tag  mortgagevariablerates:$mortgagevariableratesImageTag "$acrName.azurecr.io/mortgagevariablerates:$mortgagevariableratesImageTag"
docker tag  mortgagerateaverages:$mortgagevariableratesImageTag "$acrName.azurecr.io/mortgagerateaverages:$mortgagerateaveragesImageTag"
docker tag  mortgageui:$mortgageuiImageTag "$acrName.azurecr.io/mortgageui:$mortgageuiImageTag"
docker image ls "$acrName.azurecr.io/*"

az acr login --name $acrName

Write-Host "pushing image to Azure Container Registry $acrName" -ForegroundColor White
docker push "$acrName.azurecr.io/mortgagefixedrates:$mortgagefixedratesImageTag"
docker push "$acrName.azurecr.io/mortgagevariablerates:$mortgagevariableratesImageTag"
docker push "$acrName.azurecr.io/mortgagerateaverages:$mortgagerateaveragesImageTag"
docker push "$acrName.azurecr.io/mortgageui:$mortgageuiImageTag"