public class Main {
    static EggVoice mAnotherOpinion;

    public static void main(String[] args) {
        mAnotherOpinion = new EggVoice();
        System.out.println("Початок суперечки...");
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

class EggVoice extends Thread {
    @Override
    public void run() {
        for (int i = 0; i < 5; i++) {
            try {
                sleep(1000);
            } catch (InterruptedException e) {
            }
            System.out.println("яйце!");
        }
    }
}