class thread_quit_signal():
    def __init__(self):
        self._quit = False


    def SetQuit(self):
        self._quit=True

    def GetQuit(self):
        return self._quit