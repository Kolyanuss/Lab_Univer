public class Main2 {
    static Thread mAnotherOpinion;

    public static void main(String[] args) {
        mAnotherOpinion = new Thread(new EggVoice2());
        System.out.println("Початок суперечки з використанням класу Runnable");
        mAnotherOpinion.start();
        for (int i = 0; i < 5; i++) {
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
            }
            System.out.println("курка!");
        }
        if (mAnotherOpinion.isAlive()) {
            try {
                mAnotherOpinion.join();
            } catch (InterruptedException e) {
            }
            System.out.println("Першим було яйце!");
        } else {
            System.out.println("Першою була курка!");
        }
        System.out.println("Завершення суперечки!");
    }
}

class EggVoice2 implements Runnable {
    @Override
    public void run() {
        for (int i = 0; i < 5; i++) {
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
            }
            System.out.println("яйце!");
        }
    }
}