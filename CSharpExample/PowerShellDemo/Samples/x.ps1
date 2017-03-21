Import-Module IISAdministration
Reset-IISServerManager -Confirm:$false
Start-IISCommitDelay
$webConfig = Get-IISConfigSection -SectionPath "appSettings" -CommitPath "A2_MVC.Sample"
$collection = Get-IISConfigCollection -ConfigElement $webConfig
New-IISConfigCollectionElement -ConfigCollection $collection -ConfigAttribute @{key='key1';value='value1'}
Stop-IISCommitDelay
Remove-Module IISAdministration