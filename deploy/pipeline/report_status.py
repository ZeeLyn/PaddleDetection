import traceback

import requests


def task_heart_beat(task_id, report_url):
    if len(report_url) == 0:
        return

    try:
        requests.post(report_url, headers={"Content-Type": "application/json"}, json={"taskId": task_id}, timeout=3)
    except:
        print("上报失败")
        print(traceback.format_exc())
