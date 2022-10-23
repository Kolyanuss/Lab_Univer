import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class Main {
    static MyThread thread1;
    static MyThread thread2;

    public static void main(String[] args) throws InterruptedException {
        Counter counter = new Counter();

        thread1 = new MyThread(counter);
        thread2 = new MyThread(counter);

        ExecutorService pool = Executors.newFixedThreadPool(2);

        pool.execute(thread1);
        pool.execute(thread2);

        pool.shutdown();
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
            for (int i = 0; i < 5; i++) {
                counter.increment();
                System.out.print(counter.value());
                Thread.sleep(500);
            }
            System.out.print(" start decrement ");
            
            for (int i = 0; i < 5; i++) {
                counter.decrement();
                System.out.print(counter.value());
                Thread.sleep(500);
            }
        } catch (InterruptedException e) {
        }
    }
}

class Counter {
    private int c = 0;
    Lock lock = new ReentrantLock();

    public void increment() throws InterruptedException {
        lock.tryLock(10, TimeUnit.SECONDS);

        int a;
        Thread.sleep(150);
        a = c;
        a++;
        c = a;

        lock.unlock();
    }

    public void decrement() throws InterruptedException {
        lock.tryLock(10, TimeUnit.SECONDS);

        int a;
        Thread.sleep(100);
        a = c;
        a--;
        c = a;
        
        lock.unlock();
    }

    public int value() {
        return c;
    }
}