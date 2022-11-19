package Myconflict;

public class ConflictModify {
    private final String name;
    private static boolean isInUse = false;

    public ConflictModify(String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public synchronized void bow(ConflictModify bower) {
        checkIsInUse();
        isInUse = true;

        System.out.format(
                "%s: %s" + " пропускає мене!%n",
                this.name,
                bower.getName());

        bower.bowBack(this);
    }

    public synchronized void bowBack(ConflictModify bower) {
        System.out.format(
                "%s: %s" + " пропускає мене у вiдповiдь!%n",
                this.name,
                bower.getName());

        isInUse = false;
        notifyAll();
    }

    public synchronized void checkIsInUse() {
        while (isInUse) {
            try {
                wait();
            } catch (InterruptedException e) {}
        }
    }
}