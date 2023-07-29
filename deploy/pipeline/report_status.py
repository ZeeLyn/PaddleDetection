import traceback

import requests


class tracking_data_communicate():
    def __init__(self):
        self.total = 0
        self.in_count = 0
        self.out_count = 0

    def Set(self, total, in_count, out_count):
        self.total = total
        self.in_count = in_count
        self.out_count = out_count
        # print("total:{},in:{},out:{}".format(total,in_count,out_count))

    def Get(self):
        return {
            "total": self.total,
            "in_count": self.in_count,
            "out_count": self.out_count
        }


def task_heart_beat(task_id, report_url, _tracking_data_communicate):
    if len(report_url) == 0:
        return

    try:
        data = _tracking_data_communicate.Get()
        requests.post(report_url, headers={"Content-Type": "application/json"},
                      json={"taskId": task_id, "count": data['total']}, timeout=3)
    except:
        print("上报失败")
        print(traceback.format_exc())
