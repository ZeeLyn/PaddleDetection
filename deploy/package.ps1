pyinstaller -p "..\venv\Lib\site-packages\;.\pipeline\;.\python\;.\;.\pptracking\python\;.\pptracking\;.\pipeline\pphuman\;.\pipeline\ppvehicle\;.\libs\"  --add-binary ".\libs\*;./"   pipeline/pipeline.py
