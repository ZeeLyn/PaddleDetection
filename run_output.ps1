python deploy/pipeline/pipeline.py --config deploy/pipeline/config/infer_cfg_pphuman.yml  --heart_beat="http://localhost:34011/api/v1/task/report"  --task_id=3 --min_stay_duration=6 --draw_mark=True  --video_file="F://vlc-record-2023-09-17-12h14m29s-rtmp___rtmp01open.ys7.com_1935_v3_openlive_BA5823592_1_1-.mp4"  --output_dir=./demo_output --device=GPU  --log_folder=log/ --log_level=INFO  --imshow=True -o MOT.enable=True