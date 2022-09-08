public class Main2 {
    static MyThread thread1;
    static MyThread thread2;

    public static void main(String[] args) throws InterruptedException {
        Counter counter1 = new Counter();

        thread1 = new MyThread(counter1);
        thread2 = new MyThread(counter1);

        thread1.start();
        thread2.start();
        thread1.join();
        thread2.join();
    }
}

class MyThread extends Thread {
    Counter counter = null;

    public MyThread(Counter param) {
        this.counter = param;
    }

    @Override
    public void run() {
        try {
            counter.increment();
            System.out.println(counter.value());
            System.out.println("-");
            Thread.sleep(500);
            counter.decrement();
            System.out.println(counter.value());
        } catch (InterruptedException e) {
        }
    }
}

class Counter {
    private int c = 0;

    public void increment() throws InterruptedException {
        synchronized (this) {
            int a;
            Thread.sleep(150);
            a = c;
            a++;
            c = a;
        }
    }

    public void decrement() throws InterruptedException {
        synchronized (this) {
            int a;
            Thread.sleep(100);
            a = c;
            a--;
            c = a;
        }
    }

    public int value() {
        return c;
    }
}