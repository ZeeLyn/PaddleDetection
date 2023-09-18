import logging
import requests


class tracking_data_communicate():
    def __init__(self):
        self.total = 0
        self.in_count = 0
        self.out_count = 0

    def Set(self, total):
        self.total = total
        # self.in_count = in_count
        # self.out_count = out_count
        # print("total:{},in:{},out:{}".format(total,in_count,out_count))

    def Get(self):
        return {
            "total": self.total,
            # "in_count": self.in_count,
            # "out_count": self.out_count
        }


class tracking_data_report():
    def __init__(self, _tracking_data_communicate):
        self.last_report_count = 0
        self.tracking_data_communicate = _tracking_data_communicate
        self.logger= logging.getLogger("mylogger")

    def post(self, task_id, report_url):
        if report_url is None or len(report_url) == 0:
            return
        try:
            data = self.tracking_data_communicate.Get()
            self.logger.info("累计%s人次", str(data['total']))
            increase_count = data['total'] - self.last_report_count
            if increase_count >= 0:
                resp = requests.post(report_url, headers={"Content-Type": "application/json"},
                                     json={"taskId": task_id, "count": increase_count}, timeout=3)
                if resp.status_code == 200:
                    self.last_report_count = data['total']
                else:
                    print(resp.text)
        except:
            self.logger.error("上报数据失败",exc_info=True)
