import Myconflict.Conflict;

public class Main {
    static MyThread thread1;
    static MyThread thread2;

    public static void main(String[] args) throws InterruptedException {
        Conflict conflict1 = new Conflict("conflict1");
        Conflict conflict2 = new Conflict("conflict2");

        thread1 = new MyThread(conflict1, conflict2);
        thread2 = new MyThread(conflict2, conflict1);

        thread1.start();
        thread2.start();
    }
}

class MyThread extends Thread {
    Conflict conflict_main = null;
    Conflict conflict2 = null;

    public MyThread(Conflict param, Conflict param2) {
        this.conflict_main = param;
        this.conflict2 = param2;
    }

    @Override
    public void run() {
        conflict_main.bow(conflict2);
    }
}
