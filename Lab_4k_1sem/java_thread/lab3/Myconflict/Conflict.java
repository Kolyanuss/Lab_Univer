package Myconflict;

public class Conflict {
    private final String name;

    public Conflict(String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public synchronized void bow(Conflict bower) {
        System.out.format(
                "%s: %s" + " пропускає мене!%n",
                this.name,
                bower.getName());
        bower.bowBack(this);
    }

    public synchronized void bowBack(Conflict bower) {
        System.out.format(
                "%s: %s" + " пропускає мене у відповідь!%n",
                this.name,
                bower.getName());
    }
}