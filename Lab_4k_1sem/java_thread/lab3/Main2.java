import Myconflict.ConflictModify;

public class Main2 {
    public static void main(String[] args) throws InterruptedException {
        ConflictModify conflict_1 = new ConflictModify("conflict_1");
        ConflictModify conflict_2 = new ConflictModify("conflict_2");

        new MyThread2(conflict_1, conflict_2).start();
        new MyThread2(conflict_2, conflict_1).start();        
    }
}

class MyThread2 extends Thread {
    ConflictModify conflict_A = null;
    ConflictModify conflict_B = null;

    public MyThread2(ConflictModify param, ConflictModify param2) {
        this.conflict_A = param;
        this.conflict_B = param2;
    }

    @Override
    public void run() {
        conflict_B.checkIsInUse();

        conflict_A.changeIsInUse(true);
        conflict_B.changeIsInUse(true);
        conflict_A.bow(conflict_B);
        conflict_A.changeIsInUse(false);
        conflict_B.changeIsInUse(false);
    }
}
