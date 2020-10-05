dotnet run -p .\SirilCmd\ `
    "cd 'c:\StackBot\Multimedia\Working Files_JS\2020-8-25 Stackbot Example'" `
    "cd bias" `
    "convertraw 2240Bias_" `
    "setext fits" `
    "stack 2240Bias_ rej 3 3 -nonorm" `
    "cd .." `
    "cd flat"`
    "convertraw 2044NewFlat_" `
    "preprocess 2044NewFlat_ -bias=../bias/2240Bias_stacked" `
    "stack 2044NewFlat_ rej 3 3 -norm=mul"