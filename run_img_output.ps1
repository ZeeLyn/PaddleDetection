python deploy/pipeline/pipeline.py --config deploy/pipeline/config/infer_cfg_pphuman.yml  --heart_beat="http://localhost:34011/api/v1/task/report"  --task_id=3 --draw_mark=True --rtsp="rtmp://rtmp01open.ys7.com:1935/v3/openlive/BA5823592_1_1?expire=1694832823&id=622746869850144768&t=1f26bc5b3b96aa379b6ced282a6b6319f762c6cee65c68167828c0addd1dba33&ev=100" --device=GPU --monitor_startX=0.16  --monitor_startY=0.02 --monitor_width=0.78 --monitor_height=0.97  --imshow=True -o MOT.enable=True